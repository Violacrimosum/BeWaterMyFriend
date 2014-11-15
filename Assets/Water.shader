Shader "Custom/Water" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		
		struct Input {
			float2 uv_MainTex;
		};
		
		float time;

		void surf (Input IN, inout SurfaceOutput o) 
		{
			float2 tc = IN.uv_MainTex;
			float2 p = -1.0f + 2.0f * tc;
			
			/*float len = length(p);
			float2 uv = tc + (p/len)*cos(len*12.0f-time*4.0)*0.03;*/
			
			float2 uv = p + float2(cos(p.x*12.0f - time*4.0)*0.03,cos(p.y*12.0f - time*4.0)*0.03);
			
			half4 c = tex2D (_MainTex, uv);
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		
		/*
		uniform vec2 resolution; // Screen resolution
		uniform float time; // time in seconds
		uniform sampler2D tex0; // scene buffer
		void main(void)
		{
		  vec2 tc = gl_TexCoord[0].xy;
		  vec2 p = -1.0 + 2.0 * tc;
		  float len = length(p);
		  vec2 uv = tc + (p/len)*cos(len*12.0-time*4.0)*0.03;
		  vec3 col = texture2D(tex0,uv).xyz;
		  gl_FragColor = vec4(col,1.0);  
		  
		  */
		ENDCG
	} 
	FallBack "Diffuse"
}
