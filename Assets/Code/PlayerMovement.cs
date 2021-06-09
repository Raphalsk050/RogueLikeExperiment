using UnityEngine;

namespace Code
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody2D m_PlayerRig;
        private Vector2 m_DirectionMove;
        private float m_HorizontalMove;
        private float m_VerticalMove;
        private SpriteRenderer m_Renderer;
        private bool m_IsFlipX;

        private void Start()
        {
            m_PlayerRig = GetComponent<Rigidbody2D>();
            m_Renderer = GetComponentInChildren<SpriteRenderer>();
        }

        private void Update()
        {
            m_HorizontalMove = Input.GetAxisRaw("Horizontal");
            m_VerticalMove = Input.GetAxisRaw("Vertical");
            m_DirectionMove = new Vector2(m_HorizontalMove,m_VerticalMove).normalized;
            SpriteFlip();
        }

        private void FixedUpdate()
        {
            m_PlayerRig.velocity = m_DirectionMove * speed;
        }

        private void SpriteFlip()
        {
            if (m_HorizontalMove > 0)
            {
                m_Renderer.flipX = false;
                m_IsFlipX = m_Renderer.flipX;
            }
            else if(m_HorizontalMove < 0)
            {
                m_Renderer.flipX = true;
                m_IsFlipX = m_Renderer.flipX;
            }
            else
            {
                m_Renderer.flipX = m_IsFlipX;
            }
        }
        
    }
}
