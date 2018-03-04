<?php
    require_once "database_connect.php";
    $email=$_POST["email"];
    $password=$_POST["password"];
    
    $query="SELECT * FROM users WHERE email='$email'";
    $result=$conn->query($query);
    if($result->num_rows>0)
    {
        $user=$result->fetch_assoc();
        echo $user["password"];
        echo $password;
        if(password_verify($password, $user["password"]))     
        {
            echo "Добре дошли!";
        }
        else
        {
            echo "Грешна парола!";
        }
    }
    else
    {
        echo "Нерегистриран имейл адрес!";
    }
    $conn->close();