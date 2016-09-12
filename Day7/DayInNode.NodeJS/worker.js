var express = require('express');
var settings = require('./config');

var app = express();

app.use(require('./routes'));

app.listen(settings.HTTP_SERVER_PORT);