Shader "Tunde Shaders/ScreenSpaceGradient" {
Properties {
	_Color ("Top Color", Color) = (1,1,1,1)
	_Color2 ("Bottom Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB)", 2D) = "white" {}
}
SubShader {
	Tags { "RenderType"="Opaque" }
	LOD 200

CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
fixed4 _Color;
fixed4 _Color2;

struct Input {
	float2 uv_MainTex;
	float4 screenPos;
};

void surf (Input IN, inout SurfaceOutput o) {
	float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
	fixed4 c = lerp(_Color2, _Color, screenUV.y);
	o.Albedo = c.rgb;
	o.Alpha = c.a;
}
ENDCG
}

Fallback "Legacy Shaders/VertexLit"
}
