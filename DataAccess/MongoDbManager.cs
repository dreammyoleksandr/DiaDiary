﻿using Models;
using MongoDB.Driver;

namespace DataAccess;

public class MongoDbManager
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DbName = "diabeticslogs";
    private static readonly string collectionName = "LogEntries";
    
    private static readonly MongoClient _client = new MongoClient(ConnectionString);

    public static async Task Create(LogEntry logEntry)
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        await collection.InsertOneAsync(logEntry);
    }
    public static void Update()
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
    }
    public static void GetAll()
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        var entries = collection.Find(_ => true);

        foreach (var entry in entries.ToList())
        {
            Console.WriteLine($"Glucose level = {entry.GlucoseLevel}");
        }

    }
}