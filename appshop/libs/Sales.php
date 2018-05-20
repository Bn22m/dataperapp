<?php

/*
 * Sales.php
 */
include '../configs/dbconfig.php';
include '../views/header.php';
$userid = $_SESSION['userid'];
echo " $userid <br> ";
echo ' <a href="../index.php">log out</a> ';
echo ' <a href="../views/welcome.php">more</a> ';
echo "<br><hr><br>";

$app = new Sales($_REQUEST, $userid);
/**
 * Description of Sales
 *
 * @author Brian
 */
class Sales 
{
    var $total;
    var $discount;
    var $price;
    var $code;
    var $trade;
    var $userid;
    var $datep;
    var $datepp;
    var $balance;
    var $balance2;
    
    function __construct($sale, $user) 
    {
        $this->test($sale);
        $this->trade = [];
        $this->userid = $user;
        $this->datep = time();
        $this->trading();
    }
    
    function test($sale)
    {
        $i = 0;
        foreach ($sale as $sa)
        {
            $b = "buy".$i."";
            if(isset($sale[$b]))
            {
                echo "# $i <br>";
                $this->total = filter_var($sale["total".$i.""],FILTER_SANITIZE_STRIPPED);
                $this->discount = filter_var($sale["discount".$i.""],FILTER_SANITIZE_STRIPPED);
                $this->price = filter_var($sale["price".$i.""],FILTER_SANITIZE_STRIPPED);
                $this->code = filter_var($sale["code".$i.""], FILTER_SANITIZE_STRIPPED);
                $this->trade[] = filter_var($sa, FILTER_SANITIZE_STRIPPED);
            }
            
            $i++;
        }
        echo "///////////////////<br>";
        echo "Total: $this->total <br>";
        echo "Discount: $this->discount <br>";
        echo "Price: $this->price <br>";
        echo "Code: $this->code <br>";
        echo "///////////////////<br>";
    }
    
    function trading()
    {
        try 
        {
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            $query = "SELECT balance FROM customers WHERE id = ?";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("s", $this->userid);
            $info = $smt->execute();
            $resultb = $smt->bind_result( $this->balance);
            $fetch = $smt->fetch();
            $smt->close();
            $mysqli->close();
            $findp[] = $info;
            $findp[] = $resultb;
            $findp[] = $fetch;
            echo "Status: ".$findp[0]." <br>";
            echo "User: ".$this->userid." <br>";
            echo "Balance: ".$this->balance." <br>";
            echo "Date: ".$this->datep." <br>";
            $this->datepp = date("Y/m/d H:i:s", $this->datep);
            echo "Date: ".$this->datepp." <br>";
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCEPT:....... <br>";
            echo "$ex->getMessage()";            
        }
        if($this->total > $this->balance)
        {
            echo "Funds have been deplicated!";
            echo '<tr><td><a href="../index.php">Exit</a></td></tr>';
            exit();
        }
        
        $this->balance2 = $this->balance - $this->total;
        echo "Balance2: ".$this->balance2." <br>";
        $this->update();
        
    }
    
    function update()
    {
        try 
        {
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            $query4 = "UPDATE customers SET balance = ? WHERE id = ?";
            $query5 = "UPDATE customers SET datep = ? WHERE id = ?";
            //
            $smt = $mysqli->prepare($query4);
            $smt->bind_param('ss',$this->balance2, $this->userid);
            $smt->execute();
                       //
            $smt = $mysqli->prepare($query5);
            $smt->bind_param('ss',$this->datepp, $this->userid);
            $smt->execute();
            //
            $smt->close();
            $mysqli->close();
            
            //UPDATE
            echo "We are done.<br>";
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
            $mysqli = connDB();
            $query = "INSERT INTO transactions(user,purchase,prodcode,price,discount,balance,datep)"
                     ."VALUES(?,?,?,?,?,?,?)";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("sssssss", $this->userid, $this->total, $this->code, $this->price, $this->discount, 
                    $this->balance2, $this->datepp);
            $trans = $smt->execute();
            $smt->close();
            $mysqli->close();
            echo "Trans: $trans <br>";
            
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCE:.......... <br>";
            echo "$ex->getMessage()";            
        }
        echo date("Y/m/d H:i:s");
    }
    
}

?>


<?php
echo "<br><br>";
include "../views/footer.php";
?>