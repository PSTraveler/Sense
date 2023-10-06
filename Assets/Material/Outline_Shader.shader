Shader "Custom/Outline_Shader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _ColorStrength ("Color Strength", Range(0,4)) = 1

        _EmissionColor("Emission Color", Color) = (1,1,1,1)
        _EmissionTex("Emission (RGB)", 2D) = "white" {}
        _EmissionStrength("Emission Strength", Range(0,10)) = 1

        _Position("World Position", Vector) = (0,0,0,0)
        _Radius("Sphere Radius", Range(0,100)) = 0
        _Softness("Sphere Softness", Range(0,100)) = 0

        _Outline ("Outline", Range(1.0, 10.0)) = 1.1
        _OutlineColor ("Outline Color", Color) = (1,1,1,1)
        _OutlineStrength ("Outline Strength", Range(0,4)) = 1
        _OutlineTex("Outline Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "Queue"="transparent" "RenderType"="Opaque" }
        LOD 200

        Pass
        {
            Name "OUTLINE"
            
            ZWrite Off

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            float _Outline;
            float4 _OutlineColor;
            half _OutlineStrength;
            sampler2D _OutlineTex;

            uniform half GLOBmask_outline;

            struct vertexInput
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct vertexOutput
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            vertexOutput vert(vertexInput v)
            {
                v.vertex.xyz *= _Outline;
                vertexOutput OUT;

                OUT.pos = UnityObjectToClipPos(v.vertex);
                OUT.uv = v.uv;

                return OUT;
            }

            fixed4 frag(vertexOutput i) : SV_TARGET
            {
                _OutlineStrength = GLOBmask_outline;

                float4 texColor = tex2D(_OutlineTex, i.uv);

                return texColor * _OutlineColor * _OutlineStrength;
            }

            ENDCG
        }

        CGPROGRAM
        
        #pragma surface surf Standard fullforwardshadows

        sampler2D _MainTex;
        sampler2D _EmissionTex;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_EmissionTex;
            float3 worldPos;
        };

        half _ColorStrength, _EmissionStrength;
        fixed4 _Color, _EmissionColor;

        uniform float4 GLOBmask_pos;
        uniform half GLOBmask_rad;
        uniform half GLOBmask_soft;
        uniform half GLOBmask_strength;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            _ColorStrength = GLOBmask_strength;
            _EmissionStrength = GLOBmask_strength;

            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;

            float blackscale = (c.r + c.g + c.b) * 0.0;
            fixed3 c_g = fixed3(blackscale, blackscale, blackscale);

            fixed4 e = tex2D (_EmissionTex, IN.uv_EmissionTex) * _EmissionColor * _EmissionStrength;
            
            half d = distance(GLOBmask_pos, IN.worldPos);
            half sum = saturate((d - GLOBmask_rad) / -GLOBmask_soft);
            fixed4 lerpColor = lerp(fixed4(c_g,1), c * _ColorStrength, sum);
            fixed4 lerpEmission = lerp(fixed4(0,0,0,0), e, sum);

            o.Albedo = lerpColor.rgb;
            // Metallic and smoothness come from slider variables
            o.Emission = lerpEmission.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
}
