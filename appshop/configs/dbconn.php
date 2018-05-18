<?php

/* 
 * dbconn.php
 * @author Brian
 */
function connDB()
{
    $mysqli = new mysqli(DBHOST, DBUSER, DBPWD ,DBNAME);
    if($mysqli->errno)
    {
        print "Connection#: $mysqli->error <br>";
        echo '<tr><td><a href="../index.php">Exit</a></td></tr>';
        exit();
    }
    else 
    {
        print "Processing..<br>";    
    }
    if($mysqli->connect_errno)
    {
        print "Connection Offline: $mysqli->connect_errno <br>";
        print "Connection1: $mysqli->connect_error <br>";
        echo '<tr><td><a href="../index.php">Exit</a></td></tr>';
        exit();
    }
    return $mysqli;
}

?>
