// Copyright 2015 XLGAMES Inc.
//
// Distributed under the MIT License (See
// accompanying file "LICENSE" or the website
// http://www.opensource.org/licenses/mit-license.php)

#pragma once

#include "../RenderCore/Metal/RenderTargetView.h"
#include "../RenderCore/Metal/ShaderResource.h"
#include "../RenderCore/Metal/Format.h"
#include "../RenderCore/Metal/Forward.h"
#include "../BufferUploads/IBufferUploads.h"
#include "../BufferUploads/ResourceLocator.h"

namespace SceneEngine
{
    class LightingParserContext;

    class RefractionsBuffer
    {
    public:
        class Desc
        {
        public:
            Desc(unsigned width, unsigned height);
            unsigned _width, _height;
        };

        using SRV = RenderCore::Metal::ShaderResourceView;
        using RTV = RenderCore::Metal::RenderTargetView;
        using ResLocator = intrusive_ptr<BufferUploads::ResourceLocator>;

        void Build(
            RenderCore::Metal::DeviceContext& context, 
            LightingParserContext& parserContext,
            float standardDeviationForBlur);
        
        const SRV& GetSRV() { return _refractionsFrontSRV; }

        RefractionsBuffer(const Desc& desc);
        ~RefractionsBuffer();

    protected:
        ResLocator  _refractionsTexture[2];
        RTV         _refractionsFrontTarget;
        RTV         _refractionsBackTarget;
        SRV         _refractionsFrontSRV;
        SRV         _refractionsBackSRV;
        unsigned _width, _height;
    };

    inline RefractionsBuffer::Desc::Desc(unsigned width, unsigned height) { _width = width; _height = height; }

    class DuplicateDepthBuffer
    {
    public:
        class Desc
        {
        public:
            Desc(   unsigned width, unsigned height, 
                    RenderCore::Metal::NativeFormat::Enum format, 
                    const BufferUploads::TextureSamples& samping);
            unsigned _width, _height;
            RenderCore::Metal::NativeFormat::Enum _format;
            BufferUploads::TextureSamples _sampling;
        };

        DuplicateDepthBuffer(const Desc& desc);
        ~DuplicateDepthBuffer();

        intrusive_ptr<ID3D::Resource>              _resource;
        RenderCore::Metal::ShaderResourceView   _srv;
    };

    RenderCore::Metal::ShaderResourceView BuildDuplicatedDepthBuffer(
        RenderCore::Metal::DeviceContext* context, ID3D::Resource* sourceDepthBuffer);

}

