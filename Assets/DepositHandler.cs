using UnityEngine;
using UnityEngine.UI;
using KuBeraWallet;

public class DepositHandler : MonoBehaviour {

    public InputField tfAmount;
    public InputField tfKeyStore;
    public InputField tfPassword;
    public Wallet wallet;
    public Text txtData;

	// Use this for initialization
	void Start () {
        wallet = new Wallet();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void deposit()
    {
        string amount = tfAmount.text;
        string keystore = tfKeyStore.text;
        string password = tfPassword.text;

        keystore = @"{""version"":3,""id"":""16b0c7d6-11cb-4050-87ae-72fbed019919"",""address"":""0d332e18571eb6079eaddfed58f216b8d5831a26"",""Crypto"":{""ciphertext"":""075cdb2cc9ca3ab2ff9338a9763d433ef6398b169c298769bce87a170a6c5e82"",""cipherparams"":{""iv"":""0fa7f59ebb0ae46b3b6a9fdf0e770360""},""cipher"":""aes-128-ctr"",""kdf"":""scrypt"",""kdfparams"":{""dklen"":32,""salt"":""2abc7aa35a1911b7f9908ffc32af3b3365184c88d48824a2096d6c9806f9783a"",""n"":1024,""r"":8,""p"":1},""mac"":""ca9c7eabe78c89c044f03c3449884d15f2b5643181fa3e59b9f376587d296978""}}";
        password = "123456789";

        Debug.Log(amount + " " + keystore + " " + password);
        bool isSuccess = wallet.recoverWallet(keystore, password);

        if (isSuccess)
        {
            var rawData = wallet.getDepositRawData(amount, "4");
            txtData.text = rawData;
            Debug.Log(rawData);
        }
    }
}
