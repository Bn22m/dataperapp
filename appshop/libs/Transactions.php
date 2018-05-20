<?php

/*
 * Transactions.php
 */
include '../configs/dbconfig.php';
include '../views/header.php';

if(isset($_REQUEST['btna']))
{
	$userid = $_SESSION['userid'];
    $infob = $_REQUEST['userin'];
    $app = new Transactions($userid,$infob);	
}

/**
 * Description of Transactions
 *
 * @author Brian
 */
class Transactions 
{
    var $userid;
    var $id;
    var $topup;
    var $purchase;
	var $prodcode;
    var $price;
    var $discount;
    var $balance;
    var $datep;
	var $datepp;
    var $comments;
	var $user;
	var $info;
    
    function __construct($userp, $userinf) 
    {
        $this->userid = filter_var($userp,FILTER_SANITIZE_STRIPPED );
		$this->info = filter_var($userinf,FILTER_SANITIZE_STRIPPED );
        $this->datep = date("Y/m/d H:i:s");
        $this->view();
    }
    
    function view()
    {
        try 
        {
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            $query = "SELECT id,topup,purchase,prodcode,price,discount,balance,datep FROM transactions WHERE user = ?";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("s", $this->userid);
			$smt->execute();
            $smt->bind_result($this->id, $this->topup, $this->purchase, $this->prodcode, $this->price, $this->discount, $this->balance, $this->datepp);
            $j = 0;
			echo "<br># n:ID#TOP#PUR#PRO#PRI#DIS#BAL#DATE#";
			while ($smt->fetch())
			{
				echo "<br># $j: ";
				echo $this->id;
			    echo " :#: ";
				echo $this->topup;
			    echo " :#: ";
				echo $this->purchase;
			    echo " :#: ";
				echo $this->prodcode;
			    echo " :#: ";
				echo $this->price;
			    echo " :#: ";
                echo $this->discount;
			    echo " :#: ";
				echo $this->balance;
			    echo " :#: ";
				echo $this->datepp;
			    echo " # ";
				$j++;
			}
			//
            echo "<br><hr>";
            echo "#User: ";
            echo $this->userid;
			echo "<br>";
            echo $this->user;
			echo "<br>";
            
            echo "Enjoy!";
            echo "<br>";
            echo "#Ref: ";
			echo $this->info;
            echo "<br>";
            echo $this->datep;
            echo "<br>";
			//
			$smt->close();
            $mysqli->close();
			//
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCEPT:....... <br>";
            echo "$ex->getMessage()";            
        }
    }
}
?>

<a href="../index.php">Exit</a>
<a href="../views/welcome.php">more</a>
<hr>
<br>
<h1>Shopping API</h1>
<p>Please Enter the Userid</p>
<form action="../libs/transactions.php" method="post">
    <p><input type="text" name="userin" size="30" maxlength="60" required="true"></p>
    <p><input type="submit" name="btna" value="Enter"></p>
</form>
        
<?php
echo "<br><br>";
include "../views/footer.php";
?>