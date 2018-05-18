<?php

/*
 * Topup.php
 */
include '../configs/dbconfig.php';
include '../views/header.php';
if(!isset($_REQUEST["btntop"]))
{
    header("Location: ../views/login.php");
    exit();
} 
$user = $_SESSION["userid"];
echo "<br> user#: ".$user."<br>";
echo '<br><a href="../views/welcome.php">View more </a>';
echo "<br><hr><br>";
$app = new Topups($_REQUEST, $user);

/**
 * Description of Topups
 *
 * @author Brian
 */
class Topups 
{
    var $user;
    var $topup;
    var $balance;
    var $userid;
    var $balancep;
    
    function __construct($customer, $userp) 
    {
        $this->userid = filter_var($userp, FILTER_SANITIZE_STRIPPED);
        $this->topup = filter_var($customer["topup"], FILTER_SANITIZE_STRIPPED);;
        $this->btopup();
        $this->balancep = ($this->balance + $this->topup);
        $this->updateBalance();
    }
    
    function btopup()
    {
        try 
        {
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            $query = "SELECT name, balance FROM customers WHERE id = ?";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("s", $this->userid);
            $info = $smt->execute();
            $resultb = $smt->bind_result($this->user, $this->balance);
            $fetch = $smt->fetch();
            $smt->close();
            $mysqli->close();
            $findp[] = $info;
            $findp[] = $resultb;
            $findp[] = $fetch;
            echo "Status: ".$findp[0]." <br>";
            echo "User: ".$this->user." <br>";
            echo "Balance: ".$this->balance." <br>";
            echo "Topup: ".$this->topup." <br>";
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCEPT:....... <br>";
            echo "$ex->getMessage()";            
        }
        
    }
    
    function updateBalance()
    {
        echo "New Balance: ".$this->balancep." <br>";
        try 
        {
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            $tmep = time();
            $datepp = date("Y/m/d H:i:s",$tmep);
            echo "$datepp <br>";
            //$query = "UPDATE customers SET balance = $this->balancep WHERE id = $this->userid";
            $query3 = "UPDATE customers SET topup = ? WHERE id = ?";
            $query4 = "UPDATE customers SET balance = ? WHERE id = ?";
            $query5 = "UPDATE customers SET datep = ? WHERE id = ?";
            //
            $smt = $mysqli->prepare($query3);
            $smt->bind_param('ss',$this->topup, $this->userid);
            $smt->execute();
            //
            $smt = $mysqli->prepare($query4);
            $smt->bind_param('ss',$this->balancep, $this->userid);
            $smt->execute();
            //
            $smt = $mysqli->prepare($query5);
            $smt->bind_param('ss',$this->datep, $this->userid);
            $smt->execute();
            //
            $smt->close();
            $mysqli->close();
            
            //UPDATE
			$this->transactions();
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCE:.......... <br>";
            echo "$ex->getMessage()";            
        }
    }
	
	function transactions()
    {
        try 
        {
            include_once '../configs/dbconn.php';
			$tmep = time();
            $datept = date("Y/m/d H:i:s",$tmep);
            $mysqli = connDB();
            $query = "INSERT INTO transactions(user,topup,balance,datep)"
                     ."VALUES(?,?,?,?)";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("ssss", $this->userid, $this->topup, $this->balancep, $datept);
            $trans = $smt->execute();
            $smt->close();
            $mysqli->close();
			echo "#Trans: $trans <br>";
			echo "$datept <br>";
            
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCE:.......... <br>";
            echo "$ex->getMessage()";            
        }
    }
    
}

?>

<?php
echo "<br><br>";
include "../views/footer.php";
?>