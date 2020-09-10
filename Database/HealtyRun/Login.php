<?
	include("Connect.php");

	$id = $_POST['Id'];
	$password = $_POST['Password'];

	$strSQLId = "SELECT * FROM Player WHERE UserName = '$id'";
	$objQueryId = mysql_query($strSQLId);
	$objResultId = mysql_fetch_array($objQueryId);

	$strSQLPass = "SELECT * FROM Player WHERE Password = '$password'";
	$objQueryPass = mysql_query($strSQLPass);
	$objResultPass = mysql_fetch_array($objQueryPass);

	if(!$objResultId){
		echo "falseId";
	}else if(!$objResultPass){
		echo "falsePass";
	}else{
		echo $id;
	}
?>