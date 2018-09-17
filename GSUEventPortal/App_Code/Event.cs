using System;
using System.Collections.Generic;
using System.Web;
public class Event
{
	public int id, user_id, approved, duration, price, number_of_bookings;
    public string name, description, category_name, place, date, start_time, image_url;

    public Event(int id, int user_id, string name, string description, string category_name, string place, string date, string start_time, int duration, int price, string image_url, int approved)
    {
        this.id = id;
        this.user_id = user_id;
        this.name = name;
        this.description = description;
        this.category_name = category_name;
        this.place = place;
        this.date = date;
        this.start_time = start_time;
        this.duration = duration;
        this.price = price;
        this.image_url = image_url;
        this.approved = approved;
    }
}