var mongoose = require('mongoose');
var settings = require('./config');

mongoose.connect('mongodb://' + settings.DATABASE_CONNECTIONSTRING);

var postSchema = new mongoose.Schema({ id: Number, likes: Number });

var Post = mongoose.model('Post', postSchema);

module.exports = Post;