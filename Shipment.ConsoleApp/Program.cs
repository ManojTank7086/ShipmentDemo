﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory
{
    HostName = "localhost",  // RabbitMQ server host
    //Port = 15672,             // Specify the port you want to use
    UserName = "guest",     // RabbitMQ username
    Password = "guest",      // RabbitMQ passwor
    VirtualHost = "/"
};

//Create the RabbitMQ connection using connection factory details as i mentioned above
var connection = factory.CreateConnection();

//Here we create channel with session and model
using var channel = connection.CreateModel();

//declare the queue after mentioning name and a few property related to that
channel.QueueDeclare("product", exclusive: false);

//Set Event object which listen message from chanel which is sent by producer
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Product message received: {message}");
};

//read the message
channel.BasicConsume(queue: "product", autoAck: true, consumer: consumer);

Console.ReadKey();