// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

#ifndef UNITY_STANDARD_CORE_FORWARD_INCLUDED
#define UNITY_STANDARD_CORE_FORWARD_INCLUDED

#if defined(UNITY_NO_FULL_STANDARD_SHADER)
#   define UNITY_STANDARD_SIMPLE 1
#endif

#include "MyUnityStandardConfig.cginc"

#if UNITY_STANDARD_SIMPLE
    #include "MyUnityStandardCoreForwardSimple.cginc"
    VertexOutputBaseSimple vertBase (VertexInput v) 
    {   
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn;
        return vertForwardBaseSimple(v); 
    }
    VertexOutputForwardAddSimple vertAdd (VertexInput v) 
    { 
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn; 
        return vertForwardAddSimple(v); 
    }
    half4 fragBase (VertexOutputBaseSimple i) : SV_Target 
    { 
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn; 
        return fragForwardBaseSimpleInternal(i); 
    }
    half4 fragAdd (VertexOutputForwardAddSimple i) : SV_Target 
    { 
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn; 
        return fragForwardAddSimpleInternal(i); 
    }
#else
    #include "MyUnityStandardCore.cginc"
    VertexOutputForwardBase vertBase (VertexInput v) 
    { 
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn;
        return vertForwardBase(v); 
    }
    VertexOutputForwardAdd vertAdd (VertexInput v) 
    { 
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn;
        return vertForwardAdd(v); 
    }
    half4 fragBase (VertexOutputForwardBase i) : SV_Target 
    { 
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn;
        return fragForwardBaseInternal(i); 
    }
    half4 fragAdd (VertexOutputForwardAdd i) : SV_Target 
    { 
        unity_ObjectToWorld = MyXformMat;
        unity_WorldToObject = MyXformMatIn;
        return fragForwardAddInternal(i); 
    }
#endif

#endif // UNITY_STANDARD_CORE_FORWARD_INCLUDED
