var mysql = require('mysql');

var connection = mysql.createConnection({
    host : '127.0.0.1',
    user : root,
    port : 3307,
    database : 'test'
})

runQuery();

function runQuery() {
    var fullquery = "SELECT * from test_table limit ?";
    var final_inserts = [1];
    fullquery = mysql.format(fullquery, final_inserts);

    var connQuery = connection.query(fullquery);

    connQuery
        .on('fields', function(fields, index) {
        })
        .on('result', function(row, index) { 
            console.log(row);
        })        
        .on('end', function() {              
            console.log("All done");
            connection.end();
        });     
}