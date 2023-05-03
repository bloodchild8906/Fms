using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SharedKernel.Application.System;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

#pragma warning disable CS1591

namespace Fms.Integrations.Api.Configurations;

public static class SwaggerSetup
{
    // ReSharper disable once MethodTooLong
    public static IServiceCollection AddSwaggerSetup(this IServiceCollection services)
    {
        var commonDescription = "**Type here your swagger login page title**";
        var swaggerAuthenticatedDescription = commonDescription;
        swaggerAuthenticatedDescription += "\r\n";
        swaggerAuthenticatedDescription += "\r\nType here your swagger page description";

        var swaggerDescription = commonDescription;
        swaggerDescription += "\r\n";
        swaggerDescription += "\r\nTo access integration api login with user: demo password: demo";
        
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Fufillment Management System Api",
                    Version = "v1",
                    Description = /*language=markdown*/
"""
#### **The main api for the fulfillment management system**
below are the endpoints and a playground so have __fun__!
___
To authorise click the Authorise Button <img alt="picture" src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAZoAAAC1CAYAAABmizk0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsIAAA7CARUoSoAAABENSURBVHhe7d19cBRlgsfxX15mkkxIIAkJCTJCDCwEkSgo54pyxiJHFrCOpSxflpI7XyhcTksOPShKKVyv0D1USgrLW8stznKLLXWFuz/AM6fl5nxZPSy5y8qrJvISJSHRhLyTydv10+mJYQElkCchme+nqpnuZzo9PXT3/OZ5mZmoUCjUJQAALIn2bgEAsIKgAQBYRdAAAKwiaAAAVhE0AACrCBoAgFUEDQDAKoIGAGAVQQMAsIqgAQBYRdAAAKwiaAAAVhE0AACrCBoAgFUEDQDAKoIGAGAVQQMAsIqgAQBYRdAAAKwiaAAAVhE0AACrCBoAgFUEDQDAKoIGAGAVQQMAsIqgAQBYRdAAAKwiaAAAVhE0AACrCBoAgFUEDQDAKoIGAGAVQQMAsIqgAQBYRdAAAKwiaAAAVhE0AACrCBoAgFUEDQDAKoIGAGAVQQMAsIqgAQBYRdAAAKwiaAAAVhE0AACrCBoAgFVRLS0tXd48AAD9LqrL4c0DANDvaDoDAFhF0AAArCJoAABWETQAAKsIGgCAVQQNAMAqggYAYBVBAwCwiqABAFhF0AAArCJoAABWETQAAKsIGgCAVQQNAMAqggYAYBVBAwCwiqABAFhF0AAArCJoAABWETQAAKsIGgCAVQQNAMAqggYAYBVBAwCwiqABAFhF0AyywsJC7d2711sCgOGHoBlkRUVFuvrqq7V8+XKdOHHCKwWA4SOqy+HNYxBERUV5c1JSUpLWrFmjVatWKSEhwSsFgKGNoBlkvYMmLBgMasOGDVqyZImio+1UOsOHncOPgRQ+38923mP4ImgG2Q9dcDNnztSmTZs0Z84cr6R/mEP+ZdMJvVb5qfY0HFOos927B7DHHx2rGUmX687M6zQpcQxhE0EImkF2PhfbokWLtHHjRk2aNMkruXDmcH/RWKk1pTsIGAwKEzj/MnGxfjIik7CJEATNIDvfC83n82nFihVat26d0tLSvNK+MYe6s7NTGw6/pU/qvlLB6Km697IbNTKW/iDYV9feoq3ffKh3vt2v60deocey57tNw4TN8MeosyGira1Nmzdvdms1pjktFAp59/RNR0eH21xmEDIYSOZcM+ecYc5Bcy4iMhA0Q0xtba0eeeQRTZ06Vdu3b+9TZ75Z10zhJjNCBgMtfM6ZczB8PmL4I2iGqLKyMt12223uQIHdu3d7pT+OCxuXCs7FyEHQDHEffvihrr/+enco9NGjR71SALh0DNvBAMXFxd7cpS0/P9+bu3jx8fFauXKl1q5dq+TkZK/0e2YggOnbWbzvJXf5rZkPu7fAQJr/2Wb3dseVy+X3+619VgyXjmEbNJE8kiUjI0NPPPGEli1bptjYWK+UoIH0VXO1tlX8j/7c8LW7PD1pnJZk/ZWuCKS7ywOBoIk8HOFhqKqqyh0KnZeXp7feessrRaQ7EarXgwd+r49Plqmpo9WdzPyaL7a79wG2EDTD2P79+7VgwQIVFBSopKTEK0Wk2nb8E/d2blqu/nD1A+5k5k3ghO8DbCBoIsC7776rGTNmuE1pFRUVXukA6mhW+bEPtKO0+LSp6OtqhTq9dfqiuUblJ0pVVulMVc42zGjtrg7VHt+tnRe77WEs3Fy2PPjXSoyJcyczb3zV8q17C9hA0EQI0z+zdetWTZs2TV++/LY6Tl3YBz4vSEeT9tft0W/rSk6bXm+oUtsF9BA2nfxY67/epYe+MdOfdKDFKexqVWVDiV68yG3/qE4n0E4cUsnXpaps9sqGiKpQg3trAiYsPG/6bgBbCJoI09zcrNKX3tZ//3yDXnnlFTeArIuKU6o/VZneoisqoCn+RG+hP8RohD9NubbP6NYqlTYcVFHDER1sHFpJYwZ/MAAEg4GgiVCt1XW65557dO211+q9997zSi3xJStv9GTl9D7bosdq3uig847aW+6DxLELtCVr4unBFR2n4PhC3R8IeAWWxKUqOGKK5iVP1JQky48FDBMMb4br1ltv1TPPPKPJkyd7Jf2os1VlX72hh+pqvAIjRjen/UKrJ6S6/StNtcdVGWr17ouVPyFLweQ4hU6Wq7y1V3lHi8paTjjrHtZrLfUKKaB5SdnK8WXp2jHZqi3fpkecmkZm4GY9lZWhplNNzp9lKJiaLP/Z3laZ/p6GeineebyRXpPSafsTq8TEoDJj61TZ2KnorkY1mK/wcWppiYljlRnfqsqaKjWd7Zuwo0c6j5suvxlh3rPNDue5BZ3HuoCEvQBrvnhTnzd84y2dn4K0qfrHCQXeUv9jeHPkIWjQw3zm5oEHHtD69es1evRor7QfNB7Sq6Vv67UOKSVusuZ1HdJrITkvMjO0ZeJNCvrr9ekXv9f65nCgSLkjF+vp7DSVlXYHR9i4uKB8reU67C33iJ6gp3MK5K84ff2wRP9kPT6uQHkp3gt84xEVl/9RzzebsOpm1lk9Nl/XjWo9bX/80TEKdToB4ZuohV2l2uFmSowWZizVilEV+q3z3HacpQUyJ2mBfp0zUb7aPXr1+Afa0ebd4QgmzNDKy25wnqfdwAm/qPeVzSY2gibycITRo729XS+88IL7DdGmdtPaU5O4GB2q/W6fitwv6nVqH2k36NaRQaU4S6HQQf2x1oRCrNuH09O0Fp2snNh4Z+Yv+l1Mv05skqY76+bGhF+gYxT0peq6+FSNOMvZnBkTkOkJagod0vqvP1CZU8FRS7mKDu/URi9kUpx1TDOcu86xXfqoNqp7f7z3KiZkzOPkxAacf88t0Wwn/P7GCb6lGdny1e3Rv5Z7IePsf64v4D738pY9WnvM2x9gmCNocIaTJ09q9erVys3N1RtvvHFxX354qkq768tV68z6/VOUn5KslNTpmue+Yjer6OSXqu0MKCd7oVZ4/Su5SXN1//h0+WNO73fJTLhByycVaPlVd+tJ50Xc7aOJDmpF9t36Ve5NyundZRKVqhXjlmnr1cv0h4mFujPWBNteba/+VrXVn+rVkBMe0enuOtucdbbm3q6H452d6izXjtrvFLy8UEsTupvS/P4r9dxPfqnnpubrnokLtPT7L1tw8idOmfHpyvMH9XcpU7xwitHsUbOUl9iqsurPVOTUdhKd2ttLk5fpuenL9G/ZN2mec+WZ/dn5be/mRGB4ImhwTocPH9Ydd9yhRx991Cvpu6aT+7TTa5sKhfZo+b7Nmn9ol9uMZtSe2qfddd5CP0qJn67ZaV7yJE1QfmKqM9OhspZKfdPynRt8OYmz9Dfp3jqBLM1KHuvWNspOVaimVzPXdSPylDviHHWZwAQtzP2Fnp4yV8Hmg/rICRW/b5ruHJMlf2edykLdzXhN5rkfdJ77Z5u16PAHbviY/dnfUq2m/n/6wCWFoME5ZWdn6/XXX9ezzz7rlfRRW73215aqzFs8q65q7aw5rFBnjPy9m6rClSjnNtTV91fiuKjYnu3Jmfc5Z7rfmW3rvS2n/JzCf+vUTnw98+fWVLNbrzabUAlocdqM02tXQIQjaHCGUaNGaePGjTpw4IBuv/32Cx5YEao/qP9q6e7nyR1xk567bMH309i5ethrmipr2qcDTVFKjU9z+1PKmktU4tVyQif3qtjbRr+IinZqO2ndNZcm53HqveBprtDu+uPdNZ34LKX+QAadobVCn1Yf1AFnNiUhT7O7dmvj57/ThsPH3H4bIzFuhl7K7f4cy39MvF1bnP+DLeMW69eXT76gId7AUMKoM/Tot1FnTq2h8uh2PfRdhXr6us2osIl/q7wkb/m73dpw9GN91HP2xWlxykw11f3Ja1aKU44vRjVtze6LvysqoHkphfrl+KDaKnfpoYpSVZpOeufFfeX4G5RYvVPP1B7RAfP3zro3jyzQP0wIKnT8HT3/7SF96pXPDlypq9r26Demn8YRjA2osd17nOigHgsWKLPuP/V8XYXKnP3zx6TrzvSFujO1ScVH3tbLzfXdfU4xWbo/82ea3faeHqw64pUlK9hVrzLzWL48vZAe0JuVH6vYLEcHlOuEyjHnOZn/F7/vSj13xVzljHAWLGHUGS4FHGG4zOdo9u7dqy1btvTv0Oa+iJuipRlX6jr3rGxVWe+QMbqatT/Uql7dJ44OlbXWqLGjXW3tNd0hYzjrHgw5L+fOcmtbtUp6lf9fR7xuCi7U6kDAbU4r90Im0TdZv7p8gWandKkmVOOGjBHqqHHCwalVdTSpMtQdMt3lVTrWfERFNd0h013mhYzHN2qWVo77qRaaGlJnsw54IWOGUj8WzLcaMsClghpNhLvmmmvcPphbbrnFK+kfoYYKlTc19XxGxR89Upmp6UoMN0k5L9iVtVWq9c4+v1ODSUwOKtO0NIWanfuOO/fFaoQvVanRdapsbXW25SzHZSk4Kk5qqVZ5fZ0azd962/Y1lqv8lFnPcNb1ZyiYEnAeytmXll774stQTkpy99usZrMd56XffGDTbNfo9YFN8zf+8Ic2A+2qralQjRNqPeWxCU7ANbj78Zf8MakKpqV2f1C002yzXJVt7c6u/cAHSPvZ33++tec7zs5Xhj9Jr1x1r7fU/6jRRB6CJkLFpY/UbzY+r6VLl3KhD2Pmd2bMb86Y6ce+IeCqpMv001E57jTGf+YvtPYXgibyEDQRJhAIaOzdc3TF3beoaPY/eaXAwCFoIg9HOEKYi/nee+91+2EmLStUTLzpnQAA+wiaCDB37lzt2bNHL7/8srKysrxSABgYBM0wNnXqVO3atUvvvPOO8vLyvFIAGFgEzTCUkZGhF198USUlJZo/f75XCgCDY9gOBiguLvbmLm35+fne3MWLj4/XypUrtXbtWiUnnzlqyPyaZigU0uJ9L7nL/NoiBgODASLPsA2aoaI/RseZbdx111166qmnNH78eK/0TAQNLgUETeThCA9xN954oz755BNt27btB0OmN39096cm69pb3FtgoITPufA5iMhA0AxROTk5evPNN/X+++9r1qxZXumPM7Wfa0YE3fmt33xI2GDAmHPNnHOGOQf5rFvkoOlskPX1YktJSdHjjz+uBx980G126AtzqNva2nSooULrju1U6Gy/cw9YZmoz/3z5Qk1OypLP5yNwIgBBM8jO9yIzF+SKFSu0bt06paWleaV9Yw51uJ/my6YT+vfaP+t/G8sJHAwIEzCmJvPzlOmalDimp3+GoBn+CJpBdj4X2aJFi9zfhzG/5X+xzOHu6OhwazZmMsFjJsA2EypmMm+azBQTE0PIRAiCZpD90IU2c+ZMbdq0SXPmzPFK+oc55CZcTOCYeU4BDARzrpvJBAw1mchC0Ayys11swWBQGzZs0JIlS6wN/Qwfdg4/BlL4fCdkIgtBM8h6X3BJSUlas2aNVq1apYSEBK8UAIY2gmaQmaAxTQn33XefnnzySY0ZM8a7BwCGB4JmkBUWFrq/cDlt2jSvBACGF4IGAGAV3wwAALCKoAEAWEXQAACsImgAAFYRNAAAqwgaAIBVBA0AwCqCBgBgFUEDALCKoAEAWEXQAACsImgAAFYRNAAAqwgaAIBVBA0AwCqCBgBgFUEDALCKoAEAWEXQAACsImgAAFYRNAAAqwgaAIBVBA0AwKqoo0ePdnnzAAD0u6iamhqCBgBgTVRLSwtBAwCwJioUChE0AABrGAwAALCKoAEAWEXQAACsImgAAFYRNAAAqwgaAIBVBA0AwCqCBgBgFUEDALCKoAEAWEXQAACsImgAAFYRNAAAqwgaAIBVBA0AwCqCBgBgFUEDALCKoAEAWEXQAACsImgAAFYRNAAAqwgaAIBVBA0AwCqCBgBgFUEDALCKoAEAWEXQAACsImgAAFYRNAAAqwgaAIBVBA0AwCqCBgBgkfT/8+W7gqZTupQAAAAASUVORK5CYII=" style='display: inline; vertical-align:middle' width="300px"/></p>
""",
                    Contact = new OpenApiContact
                    {
                        Name = "Grit Procurement",
                        Url = new Uri("https://www.gritprocurement.co.za")
                    }
                });
            options.AddSignalRSwaggerGen();
            options.UseAllOfToExtendReferenceSchemas();
            options.DescribeAllParametersInCamelCase();
           // options.OrderActionsBy(x => x.RelativePath);

            var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }

            options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
            options.OperationFilter<SecurityRequirementsOperationFilter>();

            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = """
 ### How To:
 
 Enter your valid token in the text input below.
 
 #### Example:

 ```
 Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9
 ```
""",
            });

            var allGuids = typeof(IGuid).Assembly.GetTypes().Where(type => typeof(IGuid).IsAssignableFrom(type) && !type.IsInterface)
                .ToList();
            foreach (var guid in allGuids)
            {
                options.MapType(guid, () => new OpenApiSchema { Type = "string", Format = "uuid" });
            }

        });
        return services;
    }

    public static IApplicationBuilder UseSwaggerSetup(this IApplicationBuilder app)
    {
        app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocExpansion(DocExpansion.List);
                c.DisplayRequestDuration();
                c.InjectStylesheet("/css/swagger-custom.css");// css path
                c.InjectStylesheet("/fonts/stylesheet.css");
                c.InjectJavascript("/js/swagger-custom.js");
                c.DefaultModelsExpandDepth(-1);
            });
        return app;
    }
}
