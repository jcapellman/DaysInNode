var express = require('express');
var Post = require('./dbFactory');

var router = express.Router();

router.get('/api/Test', function (request, response) {
    var argId = request.params.id;

    var newPost = new Post({ id: argId, likes: 2 });

    newPost.save(function (err) {
        if (err) {
            return response.json({ message: err });
        }

        return response.json({ message: true });
    });
});

module.exports = router;