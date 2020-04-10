using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] // para aparecer no inspector do player
    private float velocidade = 2; // defini a velocidade do player 

    private Rigidbody2D rb2D; //criação de variável de manipulação do rigidbody do player
    private bool eLadoDireito; //parametro para identificar o lado q o player está virado para o pivotamento de sprite
    private Animator animator; //criação de variavel de manipulaçao do animator
    float horizontal;           //variavel para controlar player 1 Eixo X. 




    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();         //Coleta os componentes do player
        animator = GetComponent<Animator>();        // --
        eLadoDireito = transform.localScale.x > 0; // --
    }
    // Update is called once per frame
    void FixedUpdate()
    {  
        //CONTROLES (asdw - esquerda,abaixar,direita,pulo)
        horizontal = Input.GetAxis("Horizontal");   //coloca na variavel o valor o eixo Horizontal (config A e B na Unity)
        Movimentar(horizontal);                     //funçao de deslocamento que recebe o valor do eixo X (-1~1)
        MudarDirecao(horizontal);                   //função de direção que recebe o valor do eixo X (-1~1)
    }

    //******************************FUNÇÕES PARA OS CONTROLES***************************************************
    
    //MOVIMENTAÇÃO DO EIXO X
    private void Movimentar(float h)
    {
        rb2D.velocity = new Vector2(h*velocidade, rb2D.velocity.y); //parametro velocidade do rb2D = (eixo X * velocidade, mantem eixo y)
        animator.SetFloat("velocidade",Mathf.Abs(h));               //pega o valor absoluto do eixo X (-1 <= x <= 1) e joga na variavel velocidade
    }
    
    //FUNÇÃO AUXILIAR PARA MUDANÇA DE DIREÇAO
    private void MudarDirecao (float horizontal) //pega a variavel do eixo X
    {
        if(horizontal > 0 && !eLadoDireito || horizontal < 0 && eLadoDireito)// se (X > 0 && sprite pra esquerda < 0 OU X < 0 && sprite pra direita)
        {
            eLadoDireito = !eLadoDireito; // inverte o argumento e o sprite
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);// --
        }
    }

}
