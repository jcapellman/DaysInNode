var dburl = 'localhost/day2innode';
var collections = ['posts'];

var express = require('express');
var mongojs = require('mongojs');

var app = express();

app.get('/api/Test',
    function (req, res) {
        var db = mongojs(dburl, collections);

        var id = req.param('id');

        var postData = db.collection('posts');

        var newData = { 'id': id, 'likes': 2 };

        postData.insert(newData, function(err, post) {
            if (err) {
                db.close();
                return res.json({ message: err });
            }

            db.close();

            return res.json({ message: true });
        });        
    });

app.listen(1338);