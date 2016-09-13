//var express = require('express');
var restify = require('restify');

var server = restify.createServer();

var settings = require('./config');

//var app = express();
server.get("./routes");

//app.use(require('./routes'));

server.listen(settings.HTTP_SERVER_PORT);