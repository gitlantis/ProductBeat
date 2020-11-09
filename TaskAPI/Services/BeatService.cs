using System;
using TaskAPI.Models;
using TaskAPI.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAPI.Services
{
    public class BeatService
    {
        private readonly IMongoCollection<Beat> _beats;
        public BeatService(IMongoDBConnection options)
        {
            var client = new MongoClient(options.ConnectionString);
            var database = client.GetDatabase(options.DatabaseName);

            _beats = database.GetCollection<Beat>(options.CollectionName);
        }

        public async Task<List<Beat>> Get() => await 
            _beats.Find(beat => true).SortByDescending(c=>c.BeatTime).Limit(10).ToListAsync();

        public async Task<Beat> LastBeat() =>
            (await _beats.Find(beat => true).SortByDescending(c=>c.BeatTime).ToListAsync()).FirstOrDefault();

        public async Task<Beat> Create(Beat beat)
        {            
            try{

                await _beats.InsertOneAsync(beat);            
                return beat;

            }catch(Exception e){return null;}
        }

    }
}