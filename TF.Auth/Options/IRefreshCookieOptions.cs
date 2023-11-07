namespace TF.Auth.Options;

public interface IRefreshCookieOptions
{
    // validate
    public bool ValidateAudience { get; set; }

    public bool ValidateIssuer { get; set; }

    public bool ValidateLifetime { get; set; }

    public bool ValidateIssuerSigningKey { get; set; }

    #region validate params

    // lifetime validate params
    public long RefreshTokenLifeTimeTicks { get; set; }

    public long TokenLifeTimeTicks { get; set; }

    // params
    public string? ValidAudience { get; set; }

    public string? ValidIssuer { get; set; }

    public string? Secret { get; set; }

    public string? LoginPath { get; set; }

    #endregion

    public TimeSpan RefreshTokenLifeTime { get; }

    public TimeSpan TokenLifeTime { get; }
}