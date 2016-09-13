var cluster = require("cluster");

cluster.setupMaster({
    exec: 'worker.js',
    silent: true
});

var numCPUs = require("os").cpus().length;

if (cluster.isMaster) {
    for (var i = 0; i < numCPUs; i++) {
        cluster.fork();
    }

    cluster.on("exit", function (worker, code, signal) {
        cluster.fork();
    });
}