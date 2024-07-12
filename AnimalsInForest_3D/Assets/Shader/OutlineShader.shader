Shader "Custom/OutlineShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Outline ("OutlineWidth", Float) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass 
        {
            Cull Front 
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            #include "UnityCG.cginc"
            
            float _Outline;
            float4 _Color;
            
            struct v2f
            {
			    float4 pos : SV_POSITION;
	        };
	        
	        v2f vert (appdata_base v)
	        {
	            v2f output;
	            output.pos = UnityObjectToClipPos(v.vertex);
	            
	            float3 normal = normalize(mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal));
	            float2 normalProj = TransformViewToProjection(normal.xy);
	            
	            output.pos.xy += normalProj * _Outline;
	            return output;
	        }
	        
	        fixed4 frag (v2f f) : SV_Target
	        {
	            return _Color;
	        }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
