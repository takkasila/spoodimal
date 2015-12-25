<?php
	include 'connectDB.php';

    $UID = $_POST['UID'];
    $PID = $_POST['PID'];

    $sql = "SELECT * FROM TABLE_PLAYER WHERE USER_ID = $UID and PET_ID = $PID";
    $result = $con->query($sql);
    $row = $result->fetch_assoc();

    if(!$row){
        $sql = "INSERT INTO TABLE_PLAYER(USER_ID,PET_ID) VALUE('".$UID."','".$PID."')";
        $con->query($sql);
        $sql = "SELECT * FROM TABLE_PLAYER WHERE USER_ID = $UID and PET_ID = $PID";
        $result = $con->query($sql);
        $row = $result->fetch_assoc();
    }

    echo $row['PLAYER_ID'];
?>