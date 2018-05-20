<?php
/*
 * Shop.php
 */
include '../views/header.php';
include '../configs/dbconfig.php';

if(!isset($_REQUEST["login"]))
{
    header("Location: ../views/login.php");
    exit();
}

$app = new Shop($_REQUEST);

/**
 * Description of Shop
 *
 * @author Brian
 */
class Shop 
{
    
    var $user;
    var $name;
    var $email;
    var $password;
    var $reference;
    var $product;
    var $prodcode;
    var $price;
    var $discount;
    var $total;
    var $balance;
    var $datep;
    var $comments;
    var $userid;
    var $userpwd;
    
    function __construct($pshop) 
    {
        $this->email = filter_var($pshop["email"],FILTER_VALIDATE_EMAIL);
        $this->password = filter_var($pshop["password"], FILTER_SANITIZE_STRIPPED);
        $this->process(); 
    }
    
    function process ()
    {
        $temp3 = $this->email;
        if ($temp3 == "")
        {
            header("Location: ../views/login.php");
            exit();
        }
        $temp = "temp1@";
        $temp .= $this->password;
        $temp .= $this->email[0];
        $temp .= COMPANY[6];
        $temp2 = hash('sha256', $temp);
        $this->password = $temp2;
        $this->user = $temp3;
        $this->login();
    }
    
    function login()
    {
        try 
        {
            include '../configs/dbconn.php';
            $mysqli = connDB();
            $query = "SELECT id, password FROM customers WHERE email = ?";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("s", $this->user);
            $info = $smt->execute();
            $smt->bind_result($this->userid, $this->userpwd);
            $fetch = $smt->fetch();
            $smt->close();
            $mysqli->close();
            
            if($this->userpwd == $this->password)
            {
                echo "userid: $this->userid <br>";
                echo "username: $this->user <br>";
                $_SESSION['userid'] = $this->userid;
                echo "".$_SESSION['userid']."<br>";
                header("Location: ../views/welcome.php");
                exit();
            }
            else 
            {
                echo "A: $info <br>";
                echo "B: $fetch <br>";
                header("Location: ../views/login.php");
                exit();
            }
            
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCEPT:....... <br>";
            echo "$ex->getMessage()";            
        }
        
    }
    
}
?>

<?php
echo "<br><br>";
include "../views/footer.php";
?>