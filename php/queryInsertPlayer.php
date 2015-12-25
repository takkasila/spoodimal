 <?php
	include 'connectDB.php';

	// $UID = $_POST['UID'];
	// $PID = $_POST['PID'];
	$UID = 83;
	$PID = 1;

    $sql = "SELECT * FROM TABLE_PLAYER WHERE USER_ID = $UID and PET_ID = $PID";
    $result = $con->query($sql);
    $row = $result->fetch_assoc();
    if($row){
    	echo "yes";
    }
	else{
	    // $sql = "INSERT INTO TABLE_PLAYER(USER_ID,PET_ID) VALUE('".$UID."','".$PID."')";
    	// $con->query($sql);
    	echo "no";
	}
    // echo PLAYER_ID;
?>