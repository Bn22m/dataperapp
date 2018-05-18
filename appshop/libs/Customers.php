<?php

/*
 * Customers.php
 */
include '../configs/dbconfig.php';
include '../views/header.php';
if(!isset($_REQUEST["register"]))
{
    header("Location: ../views/register.php");
    exit();
}
$app = new Customers($_REQUEST);

/**
 * Description of Customers
 *
 * @author Brian
 */
class Customers 
{
    var $title;
    var $name;
    var $surname;
    var $email;
    var $address;
    var $password;
    var $topup;
    var $balance;
    var $registered;
    var $datep;
    var $user;
    var $userid;
    var $username;
    
    function __construct($customer) 
    {
        echo "Welcome to: ".COMPANY.".<br>";
        $this->title = filter_var($customer["title"], FILTER_SANITIZE_STRIPPED);
        $this->name = filter_var($customer["name"], FILTER_SANITIZE_STRIPPED);
        $this->surname = filter_var($customer["surname"], FILTER_SANITIZE_STRIPPED);
        $this->email = filter_var($customer["email"],FILTER_VALIDATE_EMAIL);
        $this->address = filter_var($customer["address"], FILTER_SANITIZE_STRIPPED);
        $this->password = filter_var($customer["password"], FILTER_SANITIZE_STRIPPED);
        $this->topup = filter_var($customer["topup"], FILTER_SANITIZE_STRIPPED);
        $this->registered = false;
        $this->datep = time();
        $this->process();
        $this->validate();
    }
    
    function validate()
    {
        echo "$this->title <br>";
        echo "$this->name <br>";
        echo "$this->surname <br>";
        echo "$this->email <br>";
        echo "$this->address <br>";
        echo "$this->password <br>";
        echo "$this->topup <br>";
        echo "$this->registered <br>";
        if($this->registered)
        {
            echo '<tr><td><a href="../views/login.php">Let\'s go shopping</a></td></tr>';
        }
        
    }
    
    function process()
    {
        $temp3 = $this->email;
        echo "$temp3 <br>";
        if($temp3 == "")
        {
            $msg = "Erro: email not valid! <br>";
            header("Location: ../views/register.php?message=$msg");
            exit();
        }
        $this->findx($temp3);
        $temp = "temp1@";
        $temp .= $this->password;
        $temp2 = hash('sha256', $temp);
        //echo "$temp2 <br>";
        $this->password = $temp2;
        $this->registerp();
    }
    
    function registerp()
    {
        try 
        {
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            echo "$mysqli->host_info <br>";
            echo "$mysqli->server_info <br>";
            $reg = true;
            $this->balance = $this->topup;
            $datepp = date("Y/m/d H:i:s", $this->datep);
            echo "$datepp <br>";
            $query = "INSERT INTO customers(title,name,surname,email,address,password,topup,balance,registered,datep)"
                     ."VALUES(?,?,?,?,?,?,?,?,?,?)";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("ssssssssss", $this->title, $this->name, $this->surname, $this->email, $this->address, 
                    $this->password, $this->topup, $this->balance, $reg, $datepp);
            $this->registered = $smt->execute();
            $smt->close();
            $mysqli->close();
            
        } 
        catch (Exception $ex) 
        {
            echo "<br> EXCE:.......... <br>";
            echo "$ex->getMessage()";            
        }
    }
    
    function findx($xuser)
    {
        $this->user = $xuser;
        try 
        {
            include '../configs/dbconn.php';
            $mysqli = connDB();
            $query = "SELECT id, name FROM customers WHERE email = ?";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("s", $this->user);
            $info = $smt->execute();
            $resultb = $smt->bind_result($this->userid, $this->username);
            $fetch = $smt->fetch();
            $smt->close();
            $mysqli->close();
            $findp[] = $info;
            $findp[] = $resultb;
            $findp[] = $this->userid;
            $findp[] = $this->username;
            $findp[] = $fetch;
            echo "01exe: $findp[0] <br>";
            echo "12res: $findp[1] <br>";
            echo "23usrid: $findp[2]  <br>";
            echo "34usrname: $findp[3] <br>";
            echo "45fetch: $findp[4] <br>";
            if($findp[2] == "")
            {
                echo "New Account <br>";
            }
            else
            {
                echo " $this->user is already registered <br>";
                echo '<tr><td><a href="../index.php">Exit</a></td></tr>';
                //header("Location: ../index.php");
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