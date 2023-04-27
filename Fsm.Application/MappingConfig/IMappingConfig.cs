using Microsoft.EntityFrameworkCore;

namespace Fsm.Application.MappingConfig;

public interface IMappingConfig
{
    void ApplyConfig();
}