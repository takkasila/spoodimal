 <?php
	include 'connectDB.php';

	$username = $_POST['username'];
	$password = md5($_POST['password']);

	$ans = array();

    $sql = "SELECT * FROM TABLE_USER WHERE USERNAME = '".$username."'";
    $result = $con->query($sql);
    $row = $result->fetch_assoc();
    if($row){
    	if($password == $row['PASSWORD']){
	    	$ans['TYPE'] = "UID";
	    	$ans['VALUE'] = $row['USER_ID'];
    	}
	    else{
	    	$ans['TYPE'] = "ERROR";
	    	$ans['VALUE'] = "Password incorrect";
	    }
    }
    else{
    	$ans['TYPE'] = "ERROR";
    	$ans['VALUE'] = "Don't have username";
    }
	echo json_encode($ans);
?>