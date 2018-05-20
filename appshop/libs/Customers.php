<?php

/*
 * Customers.php
 */
include '../views/header.php';
include '../configs/dbconfig.php';

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
    var $trans;
    var $comment;
    
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
        $this->balance = $this->topup;
        $this->trans = 0;
        $this->comment = 'New account.';
        $this->registered = false;
        $this->datep = time();
        $this->process();
        $this->validate();
        $this->findx($this->email);
        $this->transactions();
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
        $temp .= $this->email[0];
        $temp .= COMPANY[6];
        $temp2 = hash('sha256', $temp);
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
            //$this->balance = $this->topup;
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
            $useri = "";
            $usern = "";
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            $query = "SELECT id, name FROM customers WHERE email = ?";
            $smt = $mysqli->prepare($query);
            $smt->bind_param("s", $this->user);
            $info = $smt->execute();
            $resultb = $smt->bind_result($useri, $usern);
            $fetch = $smt->fetch();
            $smt->close();
            $mysqli->close();
            $this->userid = $useri;
            $this->username = $usern;
            $findp[] = $info;
            $findp[] = $resultb;
            $findp[] = $fetch;
            echo "01exec: $findp[0] <br>";
            echo "12reslt: $findp[1] <br>";
            echo "usrid: $this->userid  <br>";
            echo "usrname: $this->username <br>";
            echo "fetch: $findp[2] <br>";
            if($useri == "")
            {
                echo "$this->comment <br>";
                $this->trans = 1;
            }
            else if($this->trans === 0)
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
    
    function transactions()
    {
        try 
        {
            $datepp = date("Y/m/d H:i:s", $this->datep);
            $comment = "newAccount";
            include_once '../configs/dbconn.php';
            $mysqli = connDB();
            $query2 = "INSERT INTO transactions(user,topup,balance,datep,comments)"
                     ."VALUES(?,?,?,?,?)";
            $smt = $mysqli->prepare($query2);
            $smt->bind_param("sssss", $this->userid, $this->topup, $this->balance, $datepp, $comment);
            $trans2 = $smt->execute();
            $smt->close();
            $mysqli->close();
            echo "Trans: $trans2 <br>";
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