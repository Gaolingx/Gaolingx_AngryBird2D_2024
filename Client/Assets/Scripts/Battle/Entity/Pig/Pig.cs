public class Pig : Destructiable
{
    public int score = 3000;

    public override void Dead()
    {
        base.Dead();
        GameManager.Instance.OnPigDead();
        ScoreManager.Instance.ShowScore(transform.position, score);
    }
    protected override void PlayAudioCollision()
    {
        AudioManager.Instance.PlayPigCollision(transform.position);
    }
    protected override void PlayAudioDestroyed()
    {
    }
}
