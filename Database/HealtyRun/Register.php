<?
	include("connect.php");

	$id = $_POST['Id'];
	$password = $_POST['Password'];

	$strSQL = "SELECT * FROM Player WHERE UserName = '$id'";
	$objQurey = mysql_query($strSQL);
	$objResult = mysql_fetch_array($objQurey);

	if($objResult){
		echo "false";
	}else{
		$strSQL = "INSERT INTO Player VALUES ('$id','$password')";
		$result = mysql_query($strSQL);
		if($result){
			echo "Register Complete.";
		}else{
			echo "Register Error.";
		}
	}
?>