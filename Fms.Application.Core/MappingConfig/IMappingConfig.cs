using Microsoft.EntityFrameworkCore;

namespace Fms.Application.Core.MappingConfig;

public interface IMappingConfig
{
    void ApplyConfig();
}