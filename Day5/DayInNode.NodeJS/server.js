var dburl = 'localhost/day2innode';
var collections = ['posts'];

var express = require('express');
var mongojs = require('mongojs');

var app = express();

var db = mongojs(dburl, collections);

var postData = db.collection('posts');

app.get('/api/Test',
    function (req, res) {
        var id = req.param('id');

        var newData = { 'id': id, 'likes': 2 };

        postData.insert(newData, function(err, post) {
            if (err) {
                return res.json({ message: err });
            }
            
            return res.json({ message: true });
        });        
    });

app.listen(1338);