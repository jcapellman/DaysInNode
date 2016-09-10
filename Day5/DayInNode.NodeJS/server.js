var dburl = 'localhost/day2innode';
var collections = ['posts'];

var express = require('express');
var mongojs = require('mongojs');

var testHttp = require('TestHandler');

var app = express();

var db = mongojs(dburl, collections);

var postData = db.collection('posts');

app.get('/api/Test', testHttp.get(request, response));

app.listen(1338);