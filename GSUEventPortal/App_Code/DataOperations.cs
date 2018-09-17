using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
public class DataOperations
{
    private string connectionString = ConfigurationManager.ConnectionStrings["GSUEP"].ToString();

    private int modifyDB(string query)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    return command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e)
        {
            return -1;
        }
    }

    public User login(string email, string password)
    {
        User user = null;
        string query = @"select * from users where email = '" + email + "' and password = '" + password + "'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string name = reader["name"].ToString();
                        string type = reader["type"].ToString();
                        string security_question = reader["security_question"].ToString();
                        string security_answer = reader["security_answer"].ToString();
                        user = new User(id, name, email, password, type, security_question, security_answer);
                    }
                }
            }
        }
        return user;
    }

    public bool registerUser(User user)
    {
        string query = @"insert into users (name, email, password, type, security_question, security_answer) values
                ('" + user.name +"', '" + user.email +"', '" + user.password +"', 'normal', '" + user.security_question +"', '" + user.security_answer +"')";
        return modifyDB(query) == 1;
    }

    public bool addCategory(string category_name)
    {
        bool status = false;
        category_name = category_name.Trim().ToLower();
        string query = @"select * from categories where name like '"+category_name+"'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       
                    }
                    else
                    {
                        command.CommandText = "insert into categories (name) values('" + category_name + "')";
                        if(command.ExecuteNonQuery() == 1)
                        {
                            status = true;
                        }
                    }
                }
            }
        }
        return status;
    }

    public List<string> getCategories()
    {
        List<string> categories = new List<string>();
        string query = @"select distinct from categories";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(reader["name"].ToString());
                    }
                }
            }
        }
        return categories;
    }

    public List<string> getPlaces()
    {
        List<string> places = new List<string>();
        string query = @"select distinct place from events where approved = 1";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        places.Add(reader["place"].ToString());
                    }
                }
            }
        }
        return places;
    }

    public bool createEvent(Event eve)
    {
        string query = @"insert into events (user_id, name, description, category_name, place, date, start_time, duration, price, image_url, approved) values
                        (" + eve.user_id + ", '" + eve.name + "', '" + eve.description + "', '" + eve.category_name + "', '" + eve.place + "', '" + eve.date + "', '" + eve.start_time + "', " + eve.duration + ", " + eve.price + ", '" + eve.image_url + "', " + eve.approved + ")";
        return modifyDB(query) == 1;
    }

    public bool editEvent(Event eve)
    {
        string query = @"update events 
                         set name = '"+eve.name+"', description='"+eve.description+"', place='"+eve.place+"', category_name = '" + eve.category_name + "', date = '"+eve.date+"', start_time = '"+eve.start_time+"', duration = "+eve.duration+" where id = " + eve.id;
        return modifyDB(query) == 1;
    }

    public Event getEvent(int id)
    {
        Event eve = null;
        string query = @"select * from events where id = " + id;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int user_id = int.Parse(reader["user_id"].ToString());
                        string name = reader["name"].ToString();
                        string description = reader["description"].ToString();
                        string category_name = reader["category_name"].ToString();
                        string place = reader["place"].ToString();
                        string date = reader["date"].ToString();
                        string start_time = reader["start_time"].ToString();
                        int duration = int.Parse(reader["duration"].ToString());
                        int price = int.Parse(reader["price"].ToString());
                        string image_url = reader["image_url"].ToString();
                        int approved = int.Parse(reader["approved"].ToString());
                        eve = new Event(id, user_id, name, description, category_name, place, date, start_time, duration, price, image_url, approved);
                    }
                }
            }
        }
        return eve;
    }

    public List<Event> getEvents()
    {
        List<Event> eventList = new List<Event>();
        string query = @"select * from events";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        int user_id = int.Parse(reader["user_id"].ToString());
                        string name = reader["name"].ToString();
                        string description = reader["description"].ToString();
                        string category_name = reader["category_name"].ToString();
                        string place = reader["place"].ToString();
                        string date = reader["date"].ToString();
                        string start_time = reader["start_time"].ToString();
                        int duration = int.Parse(reader["duration"].ToString());
                        int price = int.Parse(reader["price"].ToString());
                        string image_url = reader["image_url"].ToString();
                        int approved = int.Parse(reader["approved"].ToString());
                        eventList.Add(new Event(id, user_id, name, description, category_name, place, date, start_time, duration, price, image_url, approved));
                    }
                }
            }
        }
        return eventList;
    }

    public bool deleteEvent(int event_id)
    {
        bool status = false;
        string query = @"delete from events where id = " + event_id;
        status = modifyDB(query) == 1;
        if(status)
        {
            query = @"delete from registrations where event_id = " + event_id;
            status = modifyDB(query) == 1;
        }
        return status;
    }

    public bool approveEvent(int event_id)
    {
        string query = @"update events set approved = 1 where id = " + event_id;
        return modifyDB(query) == 1;
    }

    public bool rejectEvent(int event_id)
    {
        string query = @"delete from events where id = " + event_id;
        return modifyDB(query) == 1;
    }

    public bool registerForEvent(int event_id, int user_id, int number_of_tickets)
    {
        string query = @"insert into registrations (event_id, user_id, number_of_tickets) values(" + event_id + ", " + user_id + ", " + number_of_tickets + ")";
        return modifyDB(query) == 1;
    }

    public List<Event> getRegisteredEvents(User user)
    {
        List<Event> eventList = new List<Event>();
        string query = @"select e.id, e.image_url, e.name, e.price, e.description,
e.category_name, e.place, e.date, e.start_time, e.duration, r.number_of_tickets, e.approved
from events e, registrations r
where e.id = r.event_id and r.user_id = " + user.id;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        int user_id = user.id;
                        int number_of_tickets = int.Parse(reader["number_of_tickets"].ToString());
                        string name = reader["name"].ToString();
                        string description = reader["description"].ToString();
                        string category_name = reader["category_name"].ToString();
                        string place = reader["place"].ToString();
                        string date = reader["date"].ToString();
                        string start_time = reader["start_time"].ToString();
                        int duration = int.Parse(reader["duration"].ToString());
                        int price = int.Parse(reader["price"].ToString());
                        string image_url = reader["image_url"].ToString();
                        int approved = int.Parse(reader["approved"].ToString());
                        Event ev = new Event(id, user_id, name, description, category_name, place, date, start_time, duration, price, image_url, approved);
                        ev.number_of_bookings = number_of_tickets;
                        eventList.Add(ev);
                    }
                }
            }
        }
        return eventList;
    }

    public List<User> getRegisteredUserForEvent(int event_id)
    {
        List<User> list = new List<User>();
        string query = @"select * from users where id in (select user_id from registrations where event_id = " + event_id + ")";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = int.Parse(reader["id"].ToString());
                        string name = reader["name"].ToString();
                        string email = reader["email"].ToString();
                        string password = reader["password"].ToString();
                        string type = reader["type"].ToString();
                        string security_question = reader["security_question"].ToString();
                        string security_answer = reader["security_answer"].ToString();
                        list.Add(new User(id, name, email, password, type, security_question, security_answer));
                    }
                }
            }
        }
        return list;
    }

    public bool changePassword(string email, string password)
    {
        string query = @"update users set password = '" + password + "' where email = '" + email + "'";
        return modifyDB(query) == 1;
    }

    public string getForgotPasswordDetails(string email)
    {
        string details = "";
        string query = @"select * from users where email like '" + email + "'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string password = reader["password"].ToString();
                        string security_question = reader["security_question"].ToString();
                        string security_answer = reader["security_answer"].ToString();
                        details = security_question + "?" + security_answer + "?" + password;
                    }
                }
            }
        }
        return details;
    }
}