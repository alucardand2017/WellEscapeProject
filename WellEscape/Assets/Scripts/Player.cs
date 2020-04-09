using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb2D; //criação de variável de manipulação
    float horizontal;




    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); 
        Movimentar(horizontal); //chama a função de movimentação do Player
    }




   private void Movimentar(float h) // função movimentar do player
    {
        rb2D.velocity = new Vector2(h, rb2D.velocity.y);
    }






}
