<?php

require_once "database_connect.php";
$firstName=$_POST["firstName"];
$familyName=$_POST["familyName"];
$email=$_POST["email"];
$password=$_POST["password"];
$password=password_hash($password, PASSWORD_DEFAULT);

$query="SELECT email FROM users WHERE email='$email'";
$result=$conn->query($query);
if($result->num_rows==0)
{
    $query="INSERT INTO users(first_name,family_name,email,password) VALUES('$firstName','$familyName','$email','$password')";
    $result=$conn->query($query);
}
 else
 {
     echo "Имейлът вече е зает!";
 }
$conn->close();
