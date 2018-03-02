<?php

    $servername = "localhost";
    $username =  "root";
    $password = "";
    $dbName = "explore_plovdiv";
    
    $conn = new mysqli($servername, $username, $password, $dbName);
    if(!$conn)
    {
 
        die("Connection Failed. ". mysqli_connect_error());
    }
   $conn->set_charset('utf8');