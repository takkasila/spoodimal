<?php
    include 'connectDB.php';

    $username = $_POST['username'];
    $password = md5($_POST['password']);

    $sql = "INSERT INTO TABLE_USER(USERNAME,PASSWORD) VALUE('".$username."','".$password."')";
    $con->query($sql);

    $sql = "SELECT * FROM TABLE_USER WHERE USERNAME = '".$username."'";
    $result = $con->query($sql);
    $row = $result->fetch_assoc();

    echo $row['USER_ID'];
?>