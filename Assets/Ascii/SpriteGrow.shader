Shader "Custom/SpriteGlow" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _Glow ("Glow Intensity", Range(0, 10)) = 1
    }
    SubShader {
        Tags { "Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" }
        LOD 100

        Blend SrcAlpha OneMinusSrcAlpha
        AlphaTest Greater 0.1
        Lighting Off
        ZWrite Off
        Fog { Mode Off }

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            fixed4 _GlowColor;
            float _Glow;

            v2f vert(appdata_t IN) {
                v2f OUT;
                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.uv = TRANSFORM_TEX(IN.texcoord, _MainTex);
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target {
                fixed4 texColor = tex2D(_MainTex, IN.uv);
                fixed glow = texColor.a * _Glow; // アルファ値に基づいて発光強度を調整
                fixed4 color = texColor + _GlowColor * glow;
                return color;
            }
            ENDCG
        }
    }
}