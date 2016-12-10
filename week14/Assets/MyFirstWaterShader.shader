Shader "Custom/MyFirstWaterShader" // name as it appears in Unity
{
	Properties // "public variables" for your shader
	{
		// declares a "Texture" variable for inspector
		_MainTex ("Texture", 2D) = "white" {}
		_WaveHeight ("Wave Height", Float) = 0.5 // no semi-colon
		_WaveFreq ("Wave Frequency", Float) = 2
	}
	SubShader // where our shader code actually starts
	{
		// extra metadata for Unity
		Tags { "RenderType"="Opaque" }
		LOD 100 // LOD = "level of detail"
		// more expensive shaders have higher LOD

		Pass // one "update" for your GPU
		{
			// CGPROGRAM = where our code actually starts
			CGPROGRAM // HLSL used to be called "CG"
			#pragma vertex vert // the vertex shader is called "vert"
			#pragma fragment frag // fragment shader is called "frag"
			// make fog work
			#pragma multi_compile_fog // make fog work

			// import all the shader libraries that Unity wrote already
			#include "UnityCG.cginc" // cg inc = CG include

			// struct = like a class, container for data
			// appdata = data we pass from Maya model > vertex shader
			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			// vertex 2 fragment, data from vertex shader to fragment shader
			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			// more variable declarations for use in our shader code
			sampler2D _MainTex; // this has a twin in the Properties
			float4 _MainTex_ST; // ST = scale/transform, automatically used, not declared in Properties
			float _WaveHeight;
			float _WaveFreq; // don't forget semi-colon here

			// vertex function
			v2f vert (appdata v)
			{
				v2f o;
				// multiply outside sine wave to adjust AMPLITUDE (height)
				// multiply inside sine func to adjust FREQUENCY (speed)
				v.vertex += float4(0, sin(_Time.y * _WaveFreq + v.vertex.x + v.vertex.z) * _WaveHeight, 0, 0);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			// fragment program 
			// fixed = more optimized "float"
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				// to scroll the texture (as if the water surface is flowing), we add time on top of the UV coordinates
				fixed4 col = tex2D(_MainTex, i.uv + float2(_Time.y, _Time.x) * 0.1);
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG // CG/HLSL code ends here
		}
	}
}
