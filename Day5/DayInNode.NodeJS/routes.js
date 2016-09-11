var express = require('express');
var mongojs = require('mongojs');

var dburl = 'localhost/day2innode';
var collections = ['posts'];

var db = mongojs(dburl, collections);

var postData = db.collection('posts');

var router = express.Router();

router.get('/api/Test', function (request, response) {
    var id = request.params.id;

    var newData = { 'id': id, 'likes': 2 };

    postData.insert(newData, function (err, post) {
        if (err) {
            return response.json({ message: err });
        }

        return response.json({ message: true });
    });
});


module.exports = router;