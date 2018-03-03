<?php

require_once "database_connect.php";
$firstName=$_POST["firstName"];
$familyName=$_POST["familyName"];
$email=$_POST["email"];
$password=$_POST["password"];
$password=password_hash($password, PASSWORD_DEFAULT);

$query="SELECT email FROM users WHERE email='$email' ";
$result=$conn->query($query);
if($result->numbrows==0)
{
    $query="INSERT INTO users(first_name,family_name,email,password) VALUES('$firstName','$familyName','$email','$password')";
    $result=$conn->query($query);
}
$conn->close();
