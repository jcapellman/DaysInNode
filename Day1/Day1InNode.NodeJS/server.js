var express = require('express');

var app = express();

app.get('/api/Test',
    function(req, res) {
        res.json({ message: new Date().toLocaleString() });
    });

app.listen(1338);