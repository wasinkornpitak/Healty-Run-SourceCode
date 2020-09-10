<?
	include("Connect.php");

	//Item
	$item = array();
	$all_item = array();
	$sql_all_item = "SELECT * FROM Item
					ORDER BY Id_item ASC";
	$res_all_item = mysql_query($sql_all_item);
	while ($row_all_item = mysql_fetch_assoc($res_all_item)) {
		$item = array($row_all_item);
		$all_item = array_merge($all_item, $item);
	}

	//Enemy
	$enemy = array();
	$all_enemy = array();
	$sql_all_enemy = "SELECT * FROM Enemy
					ORDER BY Id_enemy ASC";
	$res_all_enemy = mysql_query($sql_all_enemy);
	while ($row_all_enemy = mysql_fetch_assoc($res_all_enemy)) {
		$enemy = array($row_all_enemy);
		$all_enemy = array_merge($all_enemy, $enemy);
	}

	//Level
	$level = array();
	$all_level = array();
	$sql_all_level = "SELECT * FROM Level
					ORDER BY Id_level ASC";
	$res_all_level = mysql_query($sql_all_level);
	while ($row_all_level = mysql_fetch_assoc($res_all_level)) {
		$level = array($row_all_level);
		$all_level = array_merge($all_level, $level);
	}

	$retrun["Item"] = $all_item;
	$retrun["Enemy"] = $all_enemy;
	$retrun["Level"] = $all_level;
	echo json_encode($retrun);

?>