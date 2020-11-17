using FreshFruit.controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitSeller
{
    class Seller
    {
        private string name;
        private BucketController bucket;

        public Seller(string name, BucketController bucket)
        {
            this.name = name;
            this.bucket = bucket;
        }

        public List<Fruit> findAll()
        {
            return this.bucket.findAll();
        }

        public void addFruit(Fruit fruit)
        {
            this.bucket.addFruit(fruit);
        }

    }
}