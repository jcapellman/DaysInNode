var mongoose = require('mongoose');

mongoose.connect('mongodb://localhost/dayinnode');

var postSchema = new mongoose.Schema({ id: Number, likes: Number });

var Post = mongoose.model('Post', postSchema);

module.exports = Post;