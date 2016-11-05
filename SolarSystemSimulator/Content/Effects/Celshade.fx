matrix View;
matrix Projection;
matrix ViewInverse;

struct VS_INPUT
{
  float3 Position  : POSITION;
  float2 Texcoord  : TEXCOORD;
  float3 Normal    : NORMAL;
  float4 Color     : COLOR;
  float3 Tangent   : TANGENT;
  float3 Bitangent : BITANGENT;
};

struct PS_INPUT
{
  float4 Position  : SV_POSITION;
  float2 Texcoord  : TEXCOORD;
  float3 Normal    : NORMAL;
  float4 Color     : COLOR;
  float3 Tangent   : TANGENT;
  float3 Bitangent : BITANGENT;
  float3 View      : TEXCOORD1;
};

PS_INPUT VS_Main(VS_INPUT input)
{
  PS_INPUT output = (PS_INPUT)0;
  
  output.Position = mul(mul(float4(input.Position, 1), View), Projection);
  output.View = ViewInverse[3].xyz - input.Position;
  output.Texcoord = input.Texcoord;
  output.Normal = input.Normal;
  output.Color = input.Color;
  output.Tangent = input.Tangent;
  output.Bitangent = input.Bitangent;
  
  return output;
}

float4 PS_Main(PS_INPUT input) : SV_TARGET
{
  float3 Nn = normalize(input.Normal);
  float3 Vn = normalize(ViewInverse[3].xyz);
  
  return float4(saturate(float3(1,0.45f,0) * pow((1 - (dot(Vn, Nn) - 0.4)), 3)), 1);
}

technique11 Main
{
  pass p0
  {
    SetVertexShader(CompileShader(vs_5_0, VS_Main()));
    SetHullShader(NULL);
    SetDomainShader(NULL);
    SetGeometryShader(NULL);
    SetPixelShader(CompileShader(ps_5_0, PS_Main()));
  }
};
