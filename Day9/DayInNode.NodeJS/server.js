var restify = require('restify');
var settings = require('./config');
var testRouter = require('./test.router'); 

var server = restify.createServer();

testRouter.applyRoutes(server);

server.listen(settings.HTTP_SERVER_PORT);