using UnityEngine;

public class vistaCliente : MonoBehaviour
{
    private bool isFacingRight = true;

    void Update()
    {
        // Obtener la posición del mouse en coordenadas de mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Determinar si el mouse está a la derecha o izquierda del objeto
        bool isMouseRight = transform.position.x < mousePosition.x;

        // Actualizar la dirección del objeto
        Flip(isMouseRight);
    }

    private void Flip(bool isMouseRight)
    {
        if ((isFacingRight && !isMouseRight) || (!isFacingRight && isMouseRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
