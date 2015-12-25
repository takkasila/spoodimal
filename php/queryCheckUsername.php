<?php
    include 'connectDB.php';

    $username = $_POST['username'];

    $sql = "SELECT * FROM TABLE_USER";
    $result = $con->query($sql);
    while($row = $result->fetch_assoc()) {
        if($username == $row['USERNAME']){
            $check = true;
            break;
        }
        else{
            $check = false;
        }
    }
    if($check){
        echo "not_available";
    }
    else{
        echo "available";
    }
?>